using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinc
{

    public class Document
    {

    }


    //Too Large and Generic Interface
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter, IFax //...
    {

    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IScanner scanner;
        private IPrinter printer;
        private IFax fax;


        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFax fax)
        {
            if(printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }
            if (fax == null)
            {
                throw new ArgumentNullException(paramName: nameof(fax));
            }

            this.printer = printer;
            this.scanner = scanner;
            this.fax = fax;
        }

        public void Fax(Document d)
        {
            fax.Fax(d);
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        } //decorator
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        //Fax and Scan are not defined. Thus it can only implement the 
        //Print function.

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
