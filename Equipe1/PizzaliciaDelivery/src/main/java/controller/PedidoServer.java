/*
 * Autroes: Eduarda Engels, Giancarlo Cavalli, Gustavo Felipe Soares e Jardel Pereira Zermiani
 */

package controller;

import java.util.ArrayList;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

import model.Pizza;

@WebService
@SOAPBinding(style = Style.RPC)
public interface PedidoServer {

	@WebMethod
	Pizza adicionarPizza(Pizza pizza, String[] sabores);

	@WebMethod
	void removerPizza(int pizzaRemover);

	@WebMethod
	void alterarPizza(Pizza pizzaNova, String[] sabores, int pizzaRemover);

	@WebMethod
	public ArrayList<Pizza> getPizzas();
}
