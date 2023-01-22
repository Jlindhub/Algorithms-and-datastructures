using TurboCollections;


TurboLinkedList<string> customerList = new TurboLinkedList<string> { "CUSTOMER LIST" };
bool running = true;
while (running)
{
    Console.WriteLine($"current customer entries: {customerList.Count-1}");
    Console.WriteLine("choose an option: \n (1) Add a Customer \n (2) Remove a Customer by name  \n (3) Remove a Customer by index \n (4) Display all Customers \n (5) clear list and exit");
    int selector;
    try { selector = Convert.ToInt32(Console.ReadLine()); }
    catch (Exception) { selector = 42; }

    string input;
    switch (selector)
    {
        case 1:
            Console.WriteLine("please input customer name.");
            input = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                if (customerList.Contains(input))
                {
                    Console.WriteLine("this customer name is already in the list. add anyway? \n (1) Yes \n (2) No");
                    int yesOrNo;
                    try { yesOrNo = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception) { yesOrNo = 42; }
                    switch (yesOrNo)
                    {
                        case 1:                 
                            customerList.Add(input);
                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("unrecognized input. returning to menu.");
                            break;
                    }
                }
                else { customerList.Add(input); }
            }
            else { Console.WriteLine("no input detected. returning to menu.");}
            break;
        case 2:
            if (customerList.Count > 1)
            {
                Console.WriteLine("please input customer name.");
                input = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(input))
                {
                    if (customerList.Contains(input))
                    {
                        Console.WriteLine("specified entry found, deleting...");
                        customerList.Remove(input);
                        break;
                    }

                    Console.WriteLine("specified entry not found. please check spelling and try again. returning to menu.");
                }
                else
                {
                    Console.WriteLine("no input detected. returning to menu.");
                }

                break;
            }
            Console.WriteLine("the list is empty. please add someone before attempting to remove them.");
            break;
        case 3:
            if (customerList.Count > 1)
            {
                Console.WriteLine("please input customer index number.");
                int indexSelector;
                try
                {
                    indexSelector = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    indexSelector = -1;
                }

                if (indexSelector > 0)
                {
                    Console.WriteLine("specified entry found, deleting...");
                    customerList.RemoveAt(indexSelector);
                    break;
                }

                Console.WriteLine(
                    "the specified index number does not have an assigned customer. \n consult list and try again. returning to menu.");
                break;
            }
            Console.WriteLine("the list is empty. please add someone before attempting to remove them.");
            break;
        case 4:
            Console.WriteLine("displaying all customers...");
            int i = 0;
            foreach (var customer in customerList)
            {
                Console.WriteLine(i == 0 ? customer : $"index {i}:{customer}");

                i++;
            }
            break;
        case 5:
            Console.WriteLine("clearing list and exiting program...");
            customerList.Clear();
            running = false;
            break;
        default:
            Console.WriteLine("input not recognized. please try again.");
            break;
    }
}