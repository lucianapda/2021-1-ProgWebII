package controller;

import java.net.URL;

import javax.xml.namespace.QName;
import javax.xml.ws.Service;

import model.Pedido;
import model.Pizza;

public class PedidoClient {

	public static void main(String args[]) throws Exception {
		URL url = new URL("http://127.0.0.1:9876/controller?wsdl");
		QName qname = new QName("http://controller/", "PedidoControllerService");
		Service ws = Service.create(url, qname);
		PedidoServer pedido = ws.getPort(PedidoServer.class);
		Pedido ped = new Pedido();

		Pizza p1 = new Pizza('P');
		Pizza p2 = new Pizza('M');
		Pizza p3 = new Pizza('G');

		PizzaController pc = new PizzaController();
		pc.adicionarSabor(p1, "Calabresa");
		pc.adicionarSabor(p1, "4 queijos");

		pc.adicionarSabor(p2, "Portugesa");
		pc.adicionarSabor(p2, "Alho e óleo");
		pc.adicionarSabor(p2, "Margherita");

		pc.adicionarSabor(p3, "Portugesa");
		pc.adicionarSabor(p3, "Alho e óleo");
		pc.adicionarSabor(p3, "Calabresa");

		pedido.adicionarPizza(ped, p1, p1.getSabores());
		pedido.adicionarPizza(ped, p2, p2.getSabores());
		pedido.alterarPizza(ped, p2, p3);
	}
}
