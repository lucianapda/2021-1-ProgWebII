package model;

import java.util.ArrayList;

import javax.jws.WebMethod;
import javax.jws.WebService;

@WebService(endpointInterface = "model.PedidoServer")
public class PedidoServerImpl implements PedidoServer {

	private ArrayList<Pizza> pizzas = new ArrayList<Pizza>();
	private int codigo = 1;
	
	public PedidoServerImpl() {
	}

	public void adicionarPizza(Pizza pizza) {
		if (pizza == null) {
			throw new NullPointerException();
		}

		if (this.getPizzas().contains(pizza)) {
			throw new IllegalArgumentException();
		}

		pizza.setCodigo(this.getCodigo());
		this.getPizzas().add(pizza);
		this.atualizarCodigo();
		System.out.println("pizza adicionada ao pedido.");
	}

	public void removerPizza(Pizza pizza) {
		if (pizza == null) {
			throw new NullPointerException("");
		}

		if (!this.getPizzas().contains(pizza)) {
			throw new IllegalArgumentException("");
		}
		this.getPizzas().remove(pizza);
		System.out.println("pizza removida do pedido.");
	}

	public void alterarPizza(Pizza pizzaNova, Pizza pizzaAtual) {
		if (pizzaNova == null) {
			throw new NullPointerException("");
		}

		if (pizzaAtual == null) {
			throw new NullPointerException("");
		}

		if (!this.getPizzas().contains(pizzaAtual) || this.getPizzas().contains(pizzaNova)) {
			throw new IllegalArgumentException("");
		}

		this.getPizzas().remove(pizzaAtual);
		this.getPizzas().add(pizzaNova);
		System.out.println("pizza alterada.");
	}

	@WebMethod
	public ArrayList<Pizza> getPizzas() {
		return pizzas;
	}

	@WebMethod
	public int getCodigo() {
		return codigo;
	}

	@WebMethod
	private void atualizarCodigo() {
		this.codigo++;
	}

}
