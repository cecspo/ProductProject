namespace CSharp_Examination.Menus
{
    internal class StartUpMenu
    {
        
        public void MenuChoiceMenu()
        {
            var productMenus = new ProductMenus();

            Console.Clear();
            Console.WriteLine("-- WELCOME --\n");

            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. List all products");
            Console.WriteLine("3. Exit program");

            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        productMenus.AddProductMenu();
                        Console.ReadKey();
                        break;

                    case 2:
                        productMenus.ListAllProducts();
                        Console.ReadKey();
                        break;

                    case 3:
                        productMenus.ExitChoiceMenu();
                        break;

                    default:
                        Console.WriteLine("You have choicen a invalid option. Choose again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}