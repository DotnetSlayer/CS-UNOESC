package calculadora.cliente;

import calculadora.comum.Calculadora;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Cliente {
    public static void main(String[] args) {
        try {
            String ipServidor = (args.length > 0) ? args[0] : "localhost";
            System.out.println("Conectando ao servidor em: " + ipServidor);

            Registry registry = LocateRegistry.getRegistry(ipServidor, 1099);
            Calculadora calc = (Calculadora) registry.lookup("ServicoCalculadora");

            int a = 15;
            int b = 25;

            System.out.println("Soma: " + a + " + " + b + " = " + calc.somar(a, b));
            System.out.println("Subtração: " + a + " - " + b + " = " + calc.subtrair(a, b));
            System.out.println("Multiplicação: " + a + " * " + b + " = " + calc.multiplicar(a, b));
            System.out.println("Divisão: " + a + " / " + b + " = " + calc.dividir(a, b));

            try {
                System.out.println("Teste de divisão por zero: " + calc.dividir(a, 0));
            } catch (ArithmeticException e) {
                System.out.println("Erro esperado: " + e.getMessage());
            }
        } catch (Exception e) {
            System.err.println("Erro no cliente: " + e.getMessage());
            e.printStackTrace();
        }
    }
}
