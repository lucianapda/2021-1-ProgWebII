package model;

import javax.xml.ws.Endpoint;

public class PedidoServerPublisher {

	public static void main(String[] args) {
		Endpoint.publish("http://127.0.0.1:9876/model", new PedidoServerImpl());
	}

}