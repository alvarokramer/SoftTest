using FluentValidation;
using FluentValidation.Results;
using System;

namespace SoftPlanTest.Domain.Calculadora
{
    public class CalculoJuroComposto : AbstractValidator<CalculoJuroComposto>
    {
        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        public CalculoJuroComposto(decimal valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
            ValidationResult = new ValidationResult();
        }

        public decimal Calcular()
        {
            return ValorInicial * (decimal)Math.Pow(1 + 0.01, Meses);
        }

        public bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidateValorInicial();
            ValidateMeses();            
            ValidationResult = Validate(this);            
        }

        private void ValidateValorInicial()
        {
            RuleFor(c => c.ValorInicial)
                .GreaterThan(0).WithMessage("O valor inicial deve ser maior que zero");
        }

        private void ValidateMeses()
        {
            RuleFor(c => c.Meses)
                .ExclusiveBetween(1, 12).WithMessage("O número de meses deve ser entre 1 e 12");
        }
    }
}
