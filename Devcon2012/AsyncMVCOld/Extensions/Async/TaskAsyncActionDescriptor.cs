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
	public class TaskAsyncActionDescriptor : AsyncActionDescriptor
	{
		// здесь храним делегаты, которые умеют получать результат из соответствующих
		// Task'ов
		private static readonly
			ConcurrentDictionary<Type, Func<object, object>> _taskValueExtractors =
				new ConcurrentDictionary<Type, Func<object, object>>();

		private readonly string _actionName;
		private readonly ControllerDescriptor _controllerDescriptor;
		private readonly MethodInfo _methodInfo;

		/// <summary>
		/// Конструктор, сохраняет нужные данные
		/// </summary>
		/// <param name="methodInfo">данные о вызываемом action'е</param>
		/// <param name="actionName">имя action'а</param>
		/// <param name="controllerDescriptor">дескриптор контроллера</param>
		public TaskAsyncActionDescriptor(
			MethodInfo methodInfo, string actionName, ControllerDescriptor controllerDescriptor)
		{
			_methodInfo = methodInfo;
			_actionName = actionName;
			_controllerDescriptor = controllerDescriptor;
		}

		/// <summary>
		/// Получает имя выполняемого action'а
		/// </summary>
		public override string ActionName
		{
			get { return _actionName; }
		}

		/// <summary>
		/// Получает текущий дескриптор контроллера
		/// </summary>
		public override ControllerDescriptor ControllerDescriptor
		{
			get { return _controllerDescriptor; }
		}

		/// <summary>
		/// Начинает выполнение асинхронной операции, описанной в action'e
		/// </summary>
		/// <param name="controllerContext">текущий контекст контроллера</param>
		/// <param name="parameters">параметры action'а</param>
		/// <param name="callback">делегат, который вызывается после завершения
		/// асинхронной операции</param>
		/// <param name="state">дополнительное состояние</param>
		/// <returns>возвращает асинхронную операцию в виде <see cref="IAsyncResult" /></returns>
		public override IAsyncResult BeginExecute(
			ControllerContext controllerContext, IDictionary<string, object> parameters, AsyncCallback callback, object state)
		{
			var rad = new ReflectedActionDescriptor(_methodInfo, ActionName, ControllerDescriptor);
			var result = rad.Execute(controllerContext, parameters) as Task;

			if (result == null)
			{
				throw new InvalidOperationException(
					String.Format("Метод {0} должен был вернуть Task!", _methodInfo));
			}

			if (callback != null)
			{
				result.ContinueWith(_ => callback(result));
			}

			return result;
		}

		/// <summary>
		/// В конце асинхронной операции надо убедиться, что она завершена,
		/// и если нужно, обработать исключения
		/// </summary>
		/// <param name="asyncResult">состояние асинхронной операции в виде <see cref="IAsyncResult" /></param>
		/// <returns>Результат выполнения асинхронной операции. В нашем случае это
		/// Task.Result для <see cref="Task{TResult}" /> и Task.Wait() для <see cref="Task" /></returns>
		public override object EndExecute(IAsyncResult asyncResult)
		{
			// TODO: надо что-то тут сделать с асинхронными эксепшнами
			return
				_taskValueExtractors.GetOrAdd(asyncResult.GetType(), createTaskValueExtractor)(asyncResult);
		}

		/// <summary>
		/// Выполняет асинхронное действие синхронно
		/// </summary>
		/// <param name="controllerContext">контекст контроллера</param>
		/// <param name="parameters">параметры action'a</param>
		/// <returns>возвращает результат выполнения асинхронного действия синхронно</returns>
		public override object Execute(
			ControllerContext controllerContext, IDictionary<string, object> parameters)
		{
			// подумав, выбрал эксепшн. Этот метод не должен вызываться для асинхронного контроллера
			// неправильно его реализовывать через ожидание асинхронной операции, это может
			// привести к дедлоку в некоторых случаях
			throw new NotImplementedException();
		}

		/// <summary>
		///  Получает массив атрибутов, указанных для action'а
		/// </summary>
		/// <param name="inherit">true для поиска типа атрибута с учетом иерархии
		/// наследования; иначе, false</param>
		/// <returns>
		/// Массив атрибутов, или пустой массив, если атрибутов нужного типа не найдено
		/// </returns>
		public override object[] GetCustomAttributes(bool inherit)
		{
			return _methodInfo.GetCustomAttributes(inherit);
		}

		/// <summary>
		/// Получает массив атрибутов, указанных для action'а, по типу атрибута
		/// </summary>
		/// <param name="attributeType">Тип нужного атрибута</param>
		/// <param name="inherit">true для поиска типа атрибута с учетом иерархии
		/// наследования; иначе, false</param>
		/// <returns>
		/// Массив атрибутов, или пустой массив, если атрибутов нужного типа не найдено
		/// </returns>
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return _methodInfo.GetCustomAttributes(attributeType, inherit);
		}

		/// <summary>
		/// Получает параметры action'а (вызываемого метода)
		/// </summary>
		/// <returns>
		/// параметры action'а
		/// </returns>
		public override ParameterDescriptor[] GetParameters()
		{
			ParameterInfo[] parameters = _methodInfo.GetParameters();
			return Array.ConvertAll(parameters, pInfo => new ReflectedParameterDescriptor(pInfo, this));
		}

		/// <summary>
		/// Определяет, задан ли один или несколько атрибутов указанного типа для метода action'a
		/// </summary>
		/// <param name="attributeType">Тип искомого атрибута.</param>
		/// <param name="inherit">true для поиска типа атрибута с учетом иерархии
		/// наследования; иначе, false.</param>
		/// <returns>
		/// true если <paramref name="attributeType"/> задан для метода action'a; иначе, false.
		/// </returns>
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return _methodInfo.IsDefined(attributeType, inherit);
		}

		/// <summary>
		/// Создает лямбду, которая получает результат Task из
		/// </summary>
		/// <param name="taskType">Конкретный тип результата action (Task, который возвращает action)
		/// <see cref="Task" /></param>
		/// <returns></returns>
		private static Func<object, object> createTaskValueExtractor(Type taskType)
		{
			// Task<T>?
			if (taskType.IsGenericType && taskType.GetGenericTypeDefinition() == typeof (Task<>))
			{
				//в результате получаем лямбду arg => (object)(((Task<T>)arg).Result)
				ParameterExpression arg = Expression.Parameter(typeof (object));
				UnaryExpression castArg = Expression.Convert(arg, taskType);
				MemberExpression fieldAccess = Expression.Property(castArg, "Result");
				UnaryExpression castResult = Expression.Convert(fieldAccess, typeof (object));
				Expression<Func<object, object>> lambda = Expression.Lambda<Func<object, object>>(castResult, arg);
				return lambda.Compile();
			}

			// Нет возвращаемого значения, но нужно вызвать Wait(), чтобы получить эксепшны
			return theTask =>
			       	{
			       		((Task) theTask).Wait();
			       		return null;
			       	};
		}
	}
}