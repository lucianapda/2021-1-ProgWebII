package controller;

import javax.jws.WebMethod;
import javax.jws.WebService;

import model.Pizza;

@WebService
public class PizzaController {

	private Pizza pizza;

	public PizzaController(Pizza Pizza) {
		this.setPizza(Pizza);
	}

	public PizzaController() {
	}

	@WebMethod
	public void adicionarSabor(String sabor) {
		this.getPizza().adicionarSabor(sabor);
	}

	@WebMethod
	public void removerSabor(String sabor) {
		this.getPizza().removerSabor(sabor);
	}

	@WebMethod
	public String[] getSabores() {
		return this.getPizza().getSabores();
	}

	@WebMethod
	public int getPreco() {
		return this.getPizza().getPreco();
	}

	@WebMethod
	public char getTamanho() {
		return this.getPizza().getTamanho();
	}

	@WebMethod
	public void setTamanho(char tamanho) {
		this.getPizza().setTamanho(tamanho);
	}

	@WebMethod
	public int getCodigo() {
		return this.getPizza().getCodigo();
	}

	@WebMethod
	public void setCodigo(int codigo) {
		this.getPizza().setCodigo(codigo);
	}

	@WebMethod
	public Pizza getPizza() {
		return pizza;
	}

	@WebMethod
	public void setPizza(Pizza pizza) {
		this.pizza = pizza;
	}
}
