
using System;

class Program
{
  
    static int CountWords(string text)
    {
        int count = 0;         
        bool inWord = false;     

  
        for (int i = 0; i < text.Length; i++)
        {
          
            if (text[i] != ' ')
            {
               
              
                if (!inWord)
                {
                    count++;
                    inWord = true;
                }
            }
            else
            {
                
                inWord = false;
            }
        }

        return count; 
    }

    static void Main()
    {
        string text;

    
        do
        {
            Console.Write("Жолды енгізіңіз: ");
            text = Console.ReadLine() ?? "";
        }
        while (text.Length == 0);

        
        int words = CountWords(text);

       
        Console.WriteLine();
        Console.WriteLine("Бастапқы жол: " + text);
        Console.WriteLine("Сөздер саны: " + words);
    }
}
