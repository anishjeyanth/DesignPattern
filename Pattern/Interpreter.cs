namespace DesignPattern.Pattern
{
    public interface AbstractExpression
    {
        void Evaluate(Context context);
    }

    //Context: This is a class that contains the data that we want to interpret.
    public class Context
    {
        public string Expression { get; set; }
        public DateTime Date { get; set; }
        public Context(DateTime date)
        {
            this.Date = date;
        }
    }

    public class DayExpression: AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string exp = context.Expression;
            context.Expression = exp.Replace("DD", context.Date.Day.ToString());
        }
    }

    public class MonthExpression : AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string exp = context.Expression;
            context.Expression = exp.Replace("MM", context.Date.Month.ToString());
        }
    }

    public class YearExpression : AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string exp = context.Expression;
            context.Expression = exp.Replace("YYYY", context.Date.Year.ToString());
        }
    }

    internal class Interpreter
    {
        public Interpreter()
        {
            List<AbstractExpression> abstractExpressions = new List<AbstractExpression>();  
            Context context = new Context(DateTime.Now);
            context.Expression = "DD";
            string[] stringexp = { "DD", "MM", "YYYY" };
            foreach(string exp in stringexp)
            {
                if(exp == "DD")
                    abstractExpressions.Add(new DayExpression());
                else if(exp == "MM")
                    abstractExpressions.Add(new MonthExpression());
                else if (exp == "YYYY")
                    abstractExpressions.Add(new YearExpression());
            }

            foreach(AbstractExpression obj in abstractExpressions)
            {
                obj.Evaluate(context);
            }

            Console.WriteLine(context.Expression);
        }
    }
}
