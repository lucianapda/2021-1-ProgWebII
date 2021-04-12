package controller;

import java.util.ArrayList;

import javax.jws.WebMethod;
import javax.jws.WebService;

import model.PedidoServer;
import model.PedidoServerImpl;
import model.Pizza;

@WebService(endpointInterface = "model.PedidoServer")
public class PedidoController implements PedidoServer {

	private PedidoServerImpl pedido;

	public PedidoController(PedidoServerImpl pedido) {
		this.setPedido(pedido);
	}

	public PedidoController() {
	}

	public void adicionarPizza(Pizza pizza) {
		this.getPedido().adicionarPizza(pizza);
	}

	public void removerPizza(Pizza pizza) {
		this.getPedido().removerPizza(pizza);
	}

	public void alterarPizza(Pizza pizzaNova, Pizza pizzaAtual) {
		this.getPedido().alterarPizza(pizzaNova, pizzaAtual);
	}

	@WebMethod
	public ArrayList<Pizza> getPizzas() {
		return this.getPedido().getPizzas();
	}

	@WebMethod
	public int getCodigo() {
		return this.getPedido().getCodigo();
	}

	@WebMethod
	public PedidoServerImpl getPedido() {
		return pedido;
	}

	@WebMethod
	public void setPedido(PedidoServerImpl pedido) {
		this.pedido = pedido;
	}

}
