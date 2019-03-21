using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8En_tutorial
{
    public class GenericClassExampleA<T>
    {
        private T genericMemberVariable;

        public GenericClassExampleA(T value)
        {
            genericMemberVariable = value;
        }

        public T genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }

        public T genericProperty { get; set; }
    }
    public class MyDerivedClassA : GenericClassExampleA<string>
    {
        //implementation
        public MyDerivedClassA(string value) : base(value)
        {

        }
    }

    class MyDerivedClassB<U> : GenericClassExampleA<U>
    {
        public MyDerivedClassB(U value) : base(value)
        {

        }
        //implementation
    }

    class GenericClassExampleB<T> where T : class
    {
        // Implementation 
    }

    class MyDerivedClass<U> : GenericClassExampleB<U> where U : class
    {
        //implementation
    }
}
