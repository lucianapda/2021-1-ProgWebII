package model;

import java.util.ArrayList;

import javax.jws.WebMethod;

public class Pedido {

	private ArrayList<Pizza> pizzas = new ArrayList<Pizza>();
	private static int codigo = 1;

	public Pedido() {
	}

	public void adicionarPizza(Pizza pizza, String[] sabores) {
		if (pizza == null) {
			throw new NullPointerException();
		}

		if (this.getPizzas().contains(pizza)) {
			throw new IllegalArgumentException();
		}

		pizza.setCodigo(this.getCodigo());
		pizza.setSabores(sabores);
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

//		if (!this.getPizzas().contains(pizzaAtual) || this.getPizzas().contains(pizzaNova)) {
//			throw new IllegalArgumentException("");
//		}

		this.getPizzas().remove(pizzaAtual);
		this.getPizzas().add(pizzaNova);

		for (Pizza pizza : pizzas) {
			System.out.println(pizza.getCodigo());
			for (String str : pizza.getSabores()) {
				System.out.println(str);
			}
		}
		System.out.println("pizza alterada.");
	}

	public ArrayList<Pizza> getPizzas() {
		return pizzas;
	}

	public int getCodigo() {
		return codigo;
	}

	@WebMethod
	private void atualizarCodigo() {
		Pedido.codigo++;
	}

}
