/*
 * Autroes: Eduarda Engels, Giancarlo Cavalli, Gustavo Felipe Soares e Jardel Pereira Zermiani
 */

package controller;

import java.util.ArrayList;

import javax.jws.WebMethod;
import javax.jws.WebService;

import model.Pedido;
import model.Pizza;

@WebService(endpointInterface = "controller.PedidoServer")
public class PedidoController implements PedidoServer {

	private Pedido pedido;

	public PedidoController() {
		this.setPedido(new Pedido());
	}

	@Override
	public Pizza adicionarPizza(Pizza pizza, String[] sabores) {
		return this.getPedido().adicionarPizza(pizza, sabores);
	}

	@Override
	public void removerPizza(int pizzaRemover) {
		this.getPedido().removerPizza(pizzaRemover);
	}

	@Override
	public void alterarPizza(Pizza pizzaNova, String[] sabores, int pizzaRemover) {
		this.getPedido().alterarPizza(pizzaNova, sabores, pizzaRemover);
	}

	@Override
	public ArrayList<Pizza> getPizzas() {
		return this.getPedido().getPizzas();
	}

	@WebMethod
	public Pedido getPedido() {
		return pedido;
	}

	@WebMethod
	public void setPedido(Pedido pedido) {
		this.pedido = pedido;
	}
}
