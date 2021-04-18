/*
 * Autroes: Eduarda Engels, Giancarlo Cavalli, Gustavo Felipe Soares e Jardel Pereira Zermiani
 */

package model;

import java.util.ArrayList;

import javax.jws.WebMethod;

public class Pedido {

	private ArrayList<Pizza> pizzas;
	private static int codigo = 1;

	public Pedido() {
		pizzas = new ArrayList<Pizza>();
	}

	public Pizza adicionarPizza(Pizza pizza, String[] sabores) {
		if (pizza == null) {
			throw new NullPointerException("A pizza não pode ser nula");
		}

		if (this.getPizzas().contains(pizza)) {
			throw new IllegalArgumentException("Pizza já existente");
		}

		pizza.setCodigo(this.getCodigo());
		pizza.setSabores(sabores);
		this.getPizzas().add(pizza);
		this.atualizarCodigo();

		System.out.println("pizza adicionada ao pedido.\n");
		return pizza;
	}

	public void removerPizza(int pizzaRemover) {

		if (pizzaRemover >= this.getPizzas().size()) {
			throw new IllegalArgumentException(
					"O valor passado como parâmetro deve ser menor que " + this.getPizzas().size());
		}
		this.getPizzas().remove(pizzaRemover);
		System.out.println("pizza removida do pedido.");
	}

	public void alterarPizza(Pizza pizzaNova, String[] sabores, int pizzaRemover) {
		this.adicionarPizza(pizzaNova, sabores);
		this.removerPizza(pizzaRemover);
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
