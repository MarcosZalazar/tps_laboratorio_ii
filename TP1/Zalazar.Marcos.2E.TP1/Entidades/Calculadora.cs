using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operación aritmética elegida por el usuario
        /// </summary>
        /// <param name="num1"> Primer operando </param>
        /// <param name="num2"> Segundo operando </param>
        /// <param name="operador"> Operador aritmético </param>
        /// <returns> resultado= resultado de la operación aritmética</returns>
        public static double Operar (Operando num1, Operando num2, char operador)
        {
            double resultado=0;

            switch (ValidarOperador(operador)) 
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el operador recibido sea +,-,/ o *
        /// </summary>
        /// <param name="operador"> Operador aritmético a validar</param>
        /// <returns> operador: operador aritmetico validado por el método </returns>
        private static char ValidarOperador (char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador;
            }
            else 
            {
                return '+';
            }
        }
    }
}
