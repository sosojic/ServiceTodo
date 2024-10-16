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

            foreach(var item in context.Todo){
                if (item.Id>3){
                    context.Todo.Remove(item);

                }    
            context.SaveChanges();

        }
    
        
    }
}