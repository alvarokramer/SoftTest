using System;
using SoftTest.Shared.Extensions;
using FluentValidation;
using FluentValidation.Results;

namespace SoftTest.CalculadoraJuros.Domain
{
    public class CalculoJuroComposto : AbstractValidator<CalculoJuroComposto>
    {
        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }
        public double TaxaJuros { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        public CalculoJuroComposto(decimal valorInicial, int meses, double taxaJuros)
        {
            ValorInicial = valorInicial;
            Meses = meses;
            TaxaJuros = taxaJuros;
            ValidationResult = new ValidationResult();
        }

        public decimal Calcular()
        {
            var resultado = ValorInicial * (decimal)Math.Pow(1 + TaxaJuros, Meses);
            return resultado.Truncate(2);
        }

        public bool EhValido()
        {
            Validar();            
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarValorInicial();
            ValidarMeses();
            ValidationResult = Validate(this);
        }

        private void ValidarValorInicial()
        {
            RuleFor(c => c.ValorInicial)
                .GreaterThan(0).WithMessage("O valor inicial deve ser maior que zero");
        }

        private void ValidarMeses()
        {
            RuleFor(c => c.Meses)
                .ExclusiveBetween(1, 12).WithMessage("O número de meses deve ser entre 1 e 12");
        }
    }
}