package controller;

import java.util.ArrayList;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

import model.Pedido;
import model.Pizza;

@WebService
@SOAPBinding(style = Style.RPC)
public interface PedidoServer {

	@WebMethod
	void adicionarPizza(Pedido pedido,Pizza pizza, String[] sabores);

	@WebMethod
	void removerPizza(Pedido pedido,Pizza pizza);

	@WebMethod
	void alterarPizza(Pedido pedido,Pizza pizzaNova, Pizza pizzaAtual);
	
	@WebMethod
	public ArrayList<Pizza> getPizzas(Pedido pedido);
}
