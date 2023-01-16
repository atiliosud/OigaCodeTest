using FluentValidation;
using FluentValidation.Results;
using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;


namespace Oiga.Bussines.Service
{
    public class BaseService
    {
        private readonly INotification _notificador;

        protected BaseService(INotification notificador)
        {
            _notificador = notificador;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
