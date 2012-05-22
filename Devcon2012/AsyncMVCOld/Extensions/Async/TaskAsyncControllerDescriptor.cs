using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace AsyncMVCOld
{
	/// <summary>
	/// Наследник <see cref="ControllerDescriptor" />,
	/// который умеет работать с <see cref="Task" />
	/// </summary>
	public class TaskAsyncControllerDescriptor : ReflectedControllerDescriptor
	{
		/// <summary>
		/// Конструктор, вызывающий конструктор базового класса
		/// </summary>
		/// <param name="controllerType">тип контроллера</param>
		public TaskAsyncControllerDescriptor(Type controllerType)
			: base(controllerType)
		{
		}

		/// <summary>
		/// Получаем дескриптор action'а по его имени, и контексту и типу контроллера
		/// </summary>
		/// <param name="controllerContext">контекст контроллера</param>
		/// <param name="actionName">имя action'а</param>
		/// <returns>дескриптор action'a, умеющий работать с <see cref="Task" /></returns>
		public override ActionDescriptor FindAction(ControllerContext controllerContext, string actionName)
		{
			var actionDescriptor = base.FindAction(controllerContext, actionName);
			var rad = actionDescriptor as ReflectedActionDescriptor;
			var actionMethod = (rad != null) ? rad.MethodInfo : null;
			var returnType = (actionMethod != null) ? actionMethod.ReturnType : null;

			// если action возвращает Task, то создаем для него наш дескриптор
			if (returnType != null && typeof(Task).IsAssignableFrom(returnType))
			{
				return new TaskAsyncActionDescriptor(actionMethod, actionName, this);
			}

			// возвращаем обычный дескриптор
			return actionDescriptor;
		}
	}
}