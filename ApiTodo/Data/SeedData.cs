public class SeedData
{
    public static void Init()
    {        
        TodoContext context=new TodoContext();
        
        
            Todo todo1 = new Todo
            {
                Task = "Préparer mes affaires pour le canada",
                Completed = true,
                Deadline=DateTime.Parse("2024-10-16"),
            };

            Todo todo2 = new Todo
            {
                Task = "Appeler free",
                Completed = false,
                Deadline=DateTime.Parse("2025-01-07"),
            };

            Todo todo3 = new Todo
            {
                Task = "Harceler Ameli pour assurance",
                Completed = false,
                Deadline=DateTime.Parse("2025-01-07"),
            };
            
            context.Todo.AddRange(
               todo1, todo2, todo3
            );
            context.SaveChanges();

            foreach(var item in context.Todo){
                if (item.Id>3){
                    context.Todo.Remove(item);

                }    
            }
            List<Todo> agenda1_todos = new List<Todo>();
            List<Todo> agenda2_todos = new List<Todo>();
            



            Agenda agenda1=new Agenda{
            Nom="Chores",
            };
        
            Agenda agenda2=new Agenda{
            Nom="Holidays",
            };
            agenda1_todos.Add(todo2);
            agenda2_todos.Add(todo3);
            agenda1_todos.Add(todo1);



            context.SaveChanges();

            
            
    
        
    }
}