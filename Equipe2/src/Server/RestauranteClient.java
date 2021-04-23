package Server;
import javax.xml.namespace.QName;
import javax.xml.ws.Service;

import java.net.MalformedURLException;
import java.net.URL;
import java.time.LocalDate;
import java.util.Scanner;

public class RestauranteClient {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		try {
			URL url = new URL("http://localhost:9876/restauranteControle?wsdl");
			QName qname = new QName("http://Server/","ControleRestauranteService");
			Service ws = Service.create(url, qname);			
			ControleRestauranteServer cR = ws.getPort(ControleRestauranteServer.class);
			
			URL urlMesa = new URL("http://localhost:9876/mesa?wsdl");
			QName qnameMesa = new QName("http://Server/","ControleMesaService");
			Service wsMesa = Service.create(urlMesa, qnameMesa);			
			ControleMesaServer cMe = wsMesa.getPort(ControleMesaServer.class);	
				
			Mesa m1 = new Mesa();
			m1.setNumero(1);
			m1.setQtdCadeiras(2);
			m1.setDisponivel(true);
			Mesa m2 = new Mesa();
			m2.setNumero(2);
			m2.setQtdCadeiras(4);
			m2.setDisponivel(true);
			Mesa m3 = new Mesa();
			m3.setNumero(3);
			m3.setQtdCadeiras(2);
			m3.setDisponivel(false);
			Mesa m4 = new Mesa();
			m4.setNumero(4);
			m4.setQtdCadeiras(5);
			m4.setDisponivel(true);
			
			cMe.Adicionar(m1);
			cMe.Adicionar(m2);
			cMe.Adicionar(m3);
			cMe.Adicionar(m4);
			System.out.println(cMe.Listar());
			System.out.println("==============");
			System.out.println("==============");
			cMe.Alterar(true, 3, m4);
			System.out.println(cMe.Listar());
			System.out.println("==============");
			System.out.println("==============");
			
			
			Restaurante res = new Restaurante();
			res.setNome("Restaurante do Zé");
			res.setNumeroTelefone("14785236");
			
			cR.setRestaurante(res);
			cR.Adicionar(m1);
			cR.Adicionar(m2);
			cR.Adicionar(m3);
			cR.Adicionar(m4);
			System.out.println(cR.Listar());
			System.out.println("==============");
			System.out.println("==============");
			
			cR.Alterar("Restaurante do Zé", "12345678");
			System.out.println(cR.Listar());
			System.out.println("==============");
			System.out.println("==============");
			
			cR.Remover(m4);
			System.out.println(cR.Listar());
			System.out.println("==============");
			System.out.println("==============");
			
		} catch (MalformedURLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
