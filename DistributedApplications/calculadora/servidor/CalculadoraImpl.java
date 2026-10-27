package calculadora.servidor;

import calculadora.comum.Calculadora;
import java.rmi.RemoteException;
import java.rmi.server.RemoteServer;
import java.rmi.server.ServerNotActiveException;
import java.rmi.server.UnicastRemoteObject;

public class CalculadoraImpl extends UnicastRemoteObject implements Calculadora {
    public CalculadoraImpl() throws RemoteException {
        super(1099);
    }

    @Override
    public int somar(int a, int b) throws RemoteException {
        registrarOperacao("soma", a + " + " + b);
        return a + b;
    }

    @Override
    public int subtrair(int a, int b) throws RemoteException {
        registrarOperacao("subtração", a + " - " + b);
        return a - b;
    }

    @Override
    public int multiplicar(int a, int b) throws RemoteException {
        registrarOperacao("multiplicação", a + " * " + b);
        return a * b;
    }

    @Override
    public double dividir(double a, double b) throws RemoteException {
        registrarOperacao("divisão", a + " / " + b);
        if (b == 0.0) {
            throw new ArithmeticException("Não é possível dividir por zero.");
        }
        return a / b;
    }

    private void registrarOperacao(String operacao, String expressao) {
        try {
            System.out.println("[" + RemoteServer.getClientHost() + "] Pedido de "
                    + operacao + " recebido: " + expressao);
        } catch (ServerNotActiveException e) {
            System.out.println("[Local] Pedido de " + operacao + " recebido: " + expressao);
        }
    }
}
