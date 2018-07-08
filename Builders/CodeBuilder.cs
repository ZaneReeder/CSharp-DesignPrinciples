using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    //CODING EXERICSE
    //Chunks of C# Code Renderer using Builder design
    public class Field
    {
        public string Name, Type;

        public Field()
        {

        }

        public Field(string name, string type)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Type = type ?? throw new ArgumentNullException(paramName: nameof(type));
        }

        
    }

    public class CodeBuilder
    {
        private readonly string ClassName;
        public List<Field> Fields = new List<Field>();
        private const int indentSize = 3;

        public CodeBuilder(string className)
        {
            ClassName = className;
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            var f = new Field(fieldName, fieldType);
            Fields.Add(f);

            return this;
        }

        private string ToStringImpl()
        {
            var sb = new StringBuilder();
            sb.Append($"public class {ClassName}\n");
            sb.Append("{\n");

            //indention
            var i = new string(' ', indentSize);

            foreach (var f in Fields)
            {
                sb.AppendLine($"{i}public {f.Type} {f.Name};");
            }

            sb.Append("}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl();
        }
    }

    
}
