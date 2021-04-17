package controller;

import java.util.ArrayList;

import javax.jws.WebService;

import model.Pedido;
import model.Pizza;

@WebService(endpointInterface = "controller.PedidoServer")
public class PedidoController implements PedidoServer {

	public PedidoController() {
	}

	@Override
	public void adicionarPizza(Pedido pedido, Pizza pizza, String[] sabores) {
		pedido.adicionarPizza(pizza, sabores);
	}

	@Override
	public void removerPizza(Pedido pedido, Pizza pizza) {
		pedido.removerPizza(pizza);
	}

	@Override
	public void alterarPizza(Pedido pedido, Pizza pizzaNova, Pizza pizzaAtual) {
		pedido.alterarPizza(pizzaNova, pizzaAtual);
	}

	@Override
	public ArrayList<Pizza> getPizzas(Pedido pedido) {
		return pedido.getPizzas();
	}

}
