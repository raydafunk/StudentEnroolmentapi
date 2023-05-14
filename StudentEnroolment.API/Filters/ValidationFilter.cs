using FluentValidation;

namespace StudentEnroolment.API.Filters
{
    public class ValidationFilter<T> : IEndpointFilter where T : class
    {
        private readonly IValidator<T> _validator;
        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            // Runs beforte endpoint code
            var objectToValidate = context.GetArgument<T>(0);

            var validationResult = await _validator.ValidateAsync(objectToValidate);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }

            var result = await next(context);

            // Do something after endpoint code

            return result;
        }
    }
}
