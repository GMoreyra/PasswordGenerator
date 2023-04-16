using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PasswordGenerator.SwaggerFilters
{
    public class PasswordGeneratorOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.OperationId == "GeneratePassword")
            {
                operation.Summary = "Generate a random password";
                operation.Description = "Generates a random password with the specified length, upperCase, numbers, and symbols.";

                var lengthParameter = operation.Parameters.FirstOrDefault(p => p.Name == "length");
                if (lengthParameter != null)
                {
                    lengthParameter.Description = "The length of the generated password.";
                    lengthParameter.Required = true;
                    lengthParameter.Example = new OpenApiInteger(12);
                }

                var upperCaseParameter = operation.Parameters.FirstOrDefault(p => p.Name == "upperCase");
                if (upperCaseParameter != null)
                {
                    upperCaseParameter.Description = "Include uppercase characters in the generated password.";
                    upperCaseParameter.Required = true;
                    upperCaseParameter.Example = new OpenApiBoolean(true);
                }

                var numbersParameter = operation.Parameters.FirstOrDefault(p => p.Name == "numbers");
                if (numbersParameter != null)
                {
                    numbersParameter.Description = "Include numeric characters in the generated password.";
                    numbersParameter.Required = true;
                    numbersParameter.Example = new OpenApiBoolean(true);
                }

                var symbolsParameter = operation.Parameters.FirstOrDefault(p => p.Name == "symbols");
                if (symbolsParameter != null)
                {
                    symbolsParameter.Description = "Include symbols in the generated password.";
                    symbolsParameter.Required = true;
                    symbolsParameter.Example = new OpenApiBoolean(false);
                }
            }
        }
    }
}