using BLL.Security;
using DataAccessLayer;
using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        List<ErrorField> errors = new List<ErrorField>();

        public void Inserir(Usuario usuario)
        {
            usuario.Password = HashUtils.HashPassword(usuario.Password);

            //Necessário validar (vide outros BLLs)
            using (HotelContext ctx = new HotelContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuario Autenticar(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "UserName",
                    Error = "Nome de usuário deve ser informado"
                };
                errors.Add(error);
            }
            else if(username.Length < 5 || username.Length > 30)
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "UserName",
                    Error = "Nome de usuário deve conter entre 5 e 30 caracteres."
                };
                errors.Add(error);
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "Password",
                    Error = "Senha deve ser informada."
                };
                errors.Add(error);

            }
            else if (username.Length < 5 || username.Length > 30)
            {
                ErrorField error = new ErrorField()
                {
                    PropertyName = "Password",
                    Error = "Password deve conter entre 5 e 30 caracteres."
                };
                errors.Add(error);

            }
            else
            {
                int countNumbers = 0;
                int countLetters = 0;
                int countSymbols = 0;
                int countUpper = 0;
                int countLower = 0;

                foreach (char caracter in password)
                {
                    if (char.IsNumber(caracter))
                    {
                        countNumbers++;
                    }
                    else if (char.IsLetter(caracter))
                    {
                        countLetters++;
                        if (char.IsUpper(caracter))
                        {
                            countUpper++;
                        }
                        else
                        {
                            countLower++;
                        }
                    }
                    else if (char.IsSymbol(caracter))
                    {
                        countSymbols++;
                    }
                }
                if (countLetters == 0 || countLower == 0 || countNumbers == 0 || countSymbols == 0 || countUpper == 0)
                {
                    ErrorField error = new ErrorField()
                    {
                        PropertyName = "Password",
                        Error = "Senha deve conter ao menos uma letra maíuscula, uma letra minúscula, um número e um símbolo"
                    };
                    errors.Add(error);
                }
            }

            if (errors.Count != 0)
            {
                throw new HotelException(errors);
            }

            string senhaHasheada = HashUtils.HashPassword(password);

            using (HotelContext ctx = new HotelContext())
            {
                //select * from usuarios where username = 'ronaldo' and passoword = '09ur98ucvsf89f'
                Usuario user =
                    ctx.Usuarios.FirstOrDefault(u => u.UserName == username && u.Password == senhaHasheada);
                return user;
            }
        }
    }
}
