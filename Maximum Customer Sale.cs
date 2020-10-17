using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Don't change anything here.
 * Do not add any other imports. You need to write
 * this program using only these libraries 
 */
 
 
 


namespace ProgramNamespace
{
    /* You may add helper classes here if necessary */

   // Date: 17-Oct-2020
   // Authour: Manoj Batham
   // Created Public class for addding all Iteams to add All Iteams and their discount price details
 public class Items
 {
 	public int Itemid{get;set;}
 	public string ItemType{get;set;}
 	public int DiscountedPrice{get;set;}
 }
   // Date: 17-Oct-2020
   // Authour: Manoj Batham
   // Comments: Created a public class for adding all Sales with Customer detils 
public class Sales
 { 
    
 	public string CustomerName {get;set;}
    public string Address { get;set;}
    public int Day { get;set;}
    public string ItemType {get;set;}
    public string SaleType { get;set;}
    public int Price { get;set;}
 }
 
    public class Program
    {
    	
   
        public static List<String> processData(
                                        IEnumerable<string> lines)
        {
            /* 
             * Do not make any changes outside this method.
             *
             * Modify this method to process `array` as indicated
             * in the question. At the end, return a List containing
             * the appropriate values
             *
             * Do not print anything in this method
             *
             * Submit this entire program (not just this function)
             * as your answer
             */
       
       //Comments: Adding the items sold to the Sales list 
           var Sale = new List<Sales>()
         {
         	new Sales(){CustomerName="Rajan Patil", Address="Aundh",Day=1,ItemType="Phone Cover",Price=170, SaleType="Cash"},
         	new Sales(){CustomerName="Mohit Gupta", Address="Baner",Day= 1, ItemType="Samsung Battery",Price=900, SaleType="Credit Card"},
         	new Sales(){CustomerName="Rajan Patil", Address=" Aundh",Day= 3, ItemType="Samsung Battery",Price=1000, SaleType="Cash"},
			new Sales(){CustomerName="Nina Kothari", Address=" Baner",Day= 4, ItemType="Earphones",Price=500, SaleType="Credit Card"},
			new Sales(){CustomerName="T Sunitha", Address="Shivajinagar",Day= 5,ItemType=" Earphones",Price=550, SaleType=" Credit Card"},
			new Sales(){CustomerName="Rohan Gade", Address=" Aundh",Day= 10, ItemType="Motorola Battery",Price=1000, SaleType=" Credit Card"},
			new Sales(){CustomerName="Rajan Patil", Address=" Shivajinagar",Day= 21, ItemType="Earphones",Price=550, SaleType=" Credit Card"},
			new Sales(){CustomerName="Rajan Patil", Address=" Aundh",Day= 22, ItemType="USB Cable",Price=150, SaleType=" UPI"},
			new Sales(){CustomerName="Meena Kothari", Address=" Baner",Day= 23, ItemType="USB Cable",Price=100, SaleType=" Cash"},
			new Sales(){CustomerName="Nina Kothari", Address=" Baner",Day= 24, ItemType="USB Cable",Price=200, SaleType=" UPI"},
			new Sales(){CustomerName="Mohit Gupta", Address=" Baner",Day= 25, ItemType="USB Cable",Price=150, SaleType="UPI"}
         };
         
         //Comments: Added the Items list with discount price details      
          var Item = new List<Items>()
          {
          	new Items(){Itemid=1,ItemType="Phone Cover",DiscountedPrice=0},
          	new Items(){Itemid=2,ItemType="Samsung Battery",DiscountedPrice=900},
          	new Items(){Itemid=3,ItemType="Earphones",DiscountedPrice=500},
          	new Items(){Itemid=4,ItemType="Motorola Battery",DiscountedPrice=0},
          	new Items(){Itemid=5,ItemType="USB Cable",DiscountedPrice=100}
          };
          
          //Comments: List value which is returned to the main class
            List<String> retVal = new List<String>();
            
         // A for loop to go through the Item list and find out the items which are on discount
            for (int Icount = 1; Icount < Item.Count;Icount++)
            {		
            		// If a discount is greatar than 0 add it to a new list
            		if(Item[Icount].DiscountedPrice >0)
            		{
            			var GroupResult = from s in Sale group s by s.Price;
            			
            			IList<int> intList = new List<int>();
            			// loop the sales list and find ItemType which as same as in ItemList
            			foreach(var customerdetails in Sale)
	            		{
            				//If customer Item Type is same as in Item list add the amount in a new list to find the max discount price 
    	        			 if(customerdetails.ItemType == Item[Icount].ItemType)
    	        			 {
        	    				intList.Add(customerdetails.Price);
    	        			 }
            			}
            			// Variable to find a maximum price from the list
						var maxdiscount = intList.Max();
					
						//A Where query to find out the name of customer who have brought the iteam at the maximum discount
						var CustName = from s in Sale where  s.ItemType == Item[Icount].ItemType && s.Price == maxdiscount select s.CustomerName; 
						foreach (var CName in CustName)
						{
						//Adding the name of the customer who got the maximum discount which is returned to the main class
						retVal.Add(CName);
						}
						intList = new List<int>();
						maxdiscount = 0;
				
            		}
            }
            
	            
           
            return retVal;
        }

        static void Main(string[] args)
        {
            try
            {
                String line;
                var inputLines = new List<String>();
                while((line = Console.ReadLine()) != null) {
                  line = line.Trim();
                  if (line != "")
                    inputLines.Add(line);
                }
                var retVal = processData(inputLines);
                foreach(var res in retVal)
                  Console.WriteLine(res);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
