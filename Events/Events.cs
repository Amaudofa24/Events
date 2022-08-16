using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class OrderAnalyzer  //publisher
    {
        

        public delegate void InformHandler();
        public event InformHandler? NotifyOtherParties;
        
        public void OrderConfirmation()
       
        {
            int oa = 500;
           
            //This is to confirm the price inputted by clients for product
            try
            {
                if (oa == 500)
                {
                    
                    OnOrderConfirmed();
                }
                else
                {
                    Console.WriteLine("Proceed with payment");
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        protected virtual void OnOrderConfirmed()
        {
            NotifyOtherParties?.Invoke();  //raise event
        }

    }

    public class ZaraStore   //subscriber
    {
        //internal OrderAnalyzer.OrderConfirmationActions { get; private set; }

        public void ActOnOrder()
        {
            var accAn = new OrderAnalyzer();
            accAn.NotifyOtherParties += OrderConfirmationActions;
           

            accAn.OrderConfirmation();
        }



        public void OrderConfirmationActions()
        {
            Console.WriteLine("Alert business owner to cancel order");
            Console.ReadLine();
        }
    }
}
