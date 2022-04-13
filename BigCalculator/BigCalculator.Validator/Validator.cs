namespace BigCalculator.Validator
{
    using Core;

    public class Validator
    {
        public Result<string> Validate(string expression)
        {
            var iValidator = typeof(IValidator);

            var validatorsTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => iValidator.IsAssignableFrom(type) && type.IsClass);

            List<IValidator> validators = new List<IValidator>();

            foreach (var validator in validatorsTypes)
            {
                validators.Add(Activator.CreateInstance(validator) as IValidator);
            }

            foreach(var validator in validators)
            {
                var result = validator.Validate(expression);

                if (result.ResultType == ResultType.Invalid)
                {
                    return result;
                }
            }

            return new SuccessResult<string>("Success!");
        }
    }
}