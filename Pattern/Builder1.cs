using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public class Job
    {
        public string CompanyName { get; set; }
        public int Salary { get; set; }
    }

    public interface IJobBuilder
    {
        IJobBuilder WithCompanyName(string companyName);
        IJobBuilder WithSalary(int salary);

        Job Build();
    }

    public class JobBuilder : IJobBuilder
    {
        private readonly Job job;

        public JobBuilder()
        {
            job = new Job();
        }

        public IJobBuilder WithCompanyName(string companyName)
        {
            job.CompanyName = companyName;
            return this;
        }

        public IJobBuilder WithSalary(int amount)
        {
            job.Salary = amount;
            return this;
        }

        public Job Build() => job;
    }

    internal class Builder1
    {
        public Builder1()
        {
            Job job = new JobBuilder()
                        .WithCompanyName("EY Company")
                        .WithSalary(2900)
                        .Build();

            Console.WriteLine($"{job.CompanyName}-{ job.Salary}");
        }
    }
}


