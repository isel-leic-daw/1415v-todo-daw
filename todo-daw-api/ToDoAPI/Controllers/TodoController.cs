using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using ToDoAPI.StateModels;
using ToDoAPI.Store;

namespace ToDoAPI.Controllers
{
    public class ToDoController : ApiController
    {
        private ILog Log = LogManager.GetLogger(typeof (ToDoController));

        [Route("api/todo", Name = "GetAllTodos")]
        public TodoListState Get(int page = 1)
        {
            var store = new ToDoStore();
            var todos = store.GetAll(page);

            var todoListState = new TodoListState(todos, page, ToDoStore.PAGE_SIZE);
            return todoListState;
        }

        [Route("api/todo/{id}", Name = "GetTodoById")]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(200, Description = "Ok", Type = typeof(TodoState))]
        public HttpResponseMessage GetById(int id)
        {
            Log.InfoFormat("/api/todo/{0}", id);

            var store = new ToDoStore();
            var todo = store.GetById(id);
            if (todo == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var todoState = new TodoState(todo);

            return Request.CreateResponse(todoState);
        }

    }
}
