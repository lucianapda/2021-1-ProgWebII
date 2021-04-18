/*
 * Autroes: Eduarda Engels, Giancarlo Cavalli, Gustavo Felipe Soares e Jardel Pereira Zermiani
 */

package controller;

import javax.jws.WebMethod;
import javax.jws.WebService;

import model.Pizza;

@WebService
public class PizzaController {

	public PizzaController() {
	}

	@WebMethod
	public void adicionarSabor(Pizza pizza, String sabor) {
		pizza.adicionarSabor(sabor);
	}

	@WebMethod
	public void removerSabor(Pizza pizza,String sabor) {
		pizza.removerSabor(sabor);
	}

	@WebMethod
	public String[] getSabores(Pizza pizza) {
		return pizza.getSabores();
	}

	@WebMethod
	public int getPreco(Pizza pizza) {
		return pizza.getPreco();
	}

	@WebMethod
	public char getTamanho(Pizza pizza) {
		return pizza.getTamanho();
	}

	@WebMethod
	public int getCodigo(Pizza pizza) {
		return pizza.getCodigo();
	}

}
