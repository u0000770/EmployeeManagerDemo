using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerDemo
{
    public interface IInputOutput
    {
        string ReadInput(string prompt);
        void WriteOutput(string data);
    }


    public class InputOutput : IInputOutput
    {
        public string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void WriteOutput(string data)
        {
            Console.WriteLine(data);
        }
    }


}
