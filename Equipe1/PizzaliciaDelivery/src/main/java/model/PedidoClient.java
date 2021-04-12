package model;

import java.net.URL;

import javax.xml.namespace.QName;
import javax.xml.ws.Service;

public class PedidoClient {

	public static void main(String args[]) throws Exception {
		URL url = new URL("http://127.0.0.1:9876/model?wsdl");
		QName qname = new QName("http://model/", "PedidoServerImplService");
		Service ws = Service.create(url, qname);
		PedidoServer pedido = ws.getPort(PedidoServer.class);

		Pizza p1 = new Pizza('P');
		p1.adicionarSabor("Calabresa");
		p1.adicionarSabor("4 queijos");

		Pizza p2 = new Pizza('M');
		p2.adicionarSabor("Portugesa");
		p2.adicionarSabor("Alho e óleo");
		p2.adicionarSabor("Margherita");

		pedido.adicionarPizza(p1);
		pedido.adicionarPizza(p2);
	}
}
