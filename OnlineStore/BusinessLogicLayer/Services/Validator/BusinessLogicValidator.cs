namespace BusinessLogicLayer.Services.Validator;

public static class BusinessLogicValidator
{
    /// <summary>
    /// If the condition is not true, error message will be returned
    /// </summary>
    /// <param name="condition">condition: 4 > 5</param>
    /// <param name="errorMessage">Error message</param>
    /// <exception cref="BusinessException"></exception>
    public static void Validate (bool condition, string errorMessage)
    {
        if (!condition)
            throw new BusinessException(errorMessage);
    }
}
