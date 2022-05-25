namespace DesignPattern.Pattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class EmployeeManager
    {
        public EmployeeManager()
        {

        }
        public void CreateEmailAccount() 
        {
            Console.WriteLine("CreateEmailAccount");
        }

        public void UndoCreateEmailAccount()
        {
            Console.WriteLine("UndoCreateEmailAccount");
        }

        public void CreateVisitingCard()
        {
            Console.WriteLine("CreateVisitingCard");
        }

        public void UndoCreateVisitingCard()
        {
            Console.WriteLine("UndoCreateVisitingCard");
        }

        public void CreateIdentityCard()
        {
            Console.WriteLine("CreateIdentityCard");
        }

        public void UndoCreateIdentityCard()
        {
            Console.WriteLine("UndoCreateIdentityCard");
        }
    }

    public class EmailAccount : ICommand
    {
        private EmployeeManager employeeManager;
        public EmailAccount(EmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }
        public void Execute()
        {
            employeeManager.CreateEmailAccount();
        }

        public void Undo()
        {
            employeeManager.UndoCreateEmailAccount();
        }
    }

    public class IdentityCard : ICommand
    {
        private EmployeeManager employeeManager;
        public IdentityCard(EmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }
        public void Execute()
        {
            employeeManager.CreateIdentityCard();
            employeeManager.CreateVisitingCard();
        }

        public void Undo()
        {
            employeeManager.UndoCreateIdentityCard();
            employeeManager.UndoCreateVisitingCard();
        }
    }

    public class Invoker
    {
        public List<ICommand> Commands { get; set; } = new List<ICommand>();

        public void Run()
        {
            try
            {
                foreach (ICommand command in Commands)
                {
                    command.Execute();
                }
            }
            catch
            {
                foreach (ICommand command in Commands)
                {
                    command.Undo();
                }
            }
        }
    }

    internal class Command
    {
        public Command()
        {
            EmployeeManager employeeManager = new EmployeeManager();
            Invoker invoker = new Invoker();
            ICommand command = null;
            command = new EmailAccount(employeeManager);
            invoker.Commands.Add(command);
            command = new IdentityCard(employeeManager);
            invoker.Commands.Add(command);
            invoker.Run();
        }
    }
}
