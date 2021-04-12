package model;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public interface PedidoServer {

	@WebMethod
	void adicionarPizza(Pizza pizza);

	@WebMethod
	void removerPizza(Pizza pizza);

	@WebMethod
	void alterarPizza(Pizza pizzaNova, Pizza pizzaAtual);
}
