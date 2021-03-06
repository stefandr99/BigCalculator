namespace BigCalculator.Validator
{
    using Core;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Validator
    {
        public Result<string> Validate(Data data)
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
                var result = validator.Validate(data);

                if (result.ResultType == ResultType.Invalid)
                {
                    return result;
                }
            }

            return new SuccessResult<string>("Success!");
        }
    }
}