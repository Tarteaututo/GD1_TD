class Test
{
    Test myTest;
    private int myInteger = 1;
    float myFloat = 1.5f;
    string myString = "Blabla";

    bool HasTargetInRange()
    {
        return true; 
        // return false
    }

    void Main()
    {
        MyMethod();

        // On appelle Sum et récupère le résultat dans result
        int result = Sum(2, 3);

        bool hasTarget = HasTargetInRange();

        if (hasTarget == true)
        {
            int result2 = Sum(2, 3);
        }
        else
        {
            // blabla
        }

        
    }

    void MyMethod()
    {
    }

    int Sum(int a, int b)
    {
        // On calcule la somme de a et b et retourne le résultat
        int /* inline commentary */ result = a + b;
        return result;
    }
}

