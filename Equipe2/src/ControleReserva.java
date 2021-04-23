import java.time.LocalDate;
import java.util.Date;
import java.util.HashMap;

import javax.jws.WebService;

@WebService(endpointInterface = "ControleReservaServer")
public class ControleReserva implements ControleReservaServer{

	public HashMap<String, Reserva> reservas = new HashMap<>();
	
	@Override
	public void Adicionar(Reserva reserva) {
		reservas.put(reserva.getNome(), reserva);
		
	}

	@Override
	public void Alterar(Reserva reserva, String nome, int qtdpessoas, String numeroCon, LocalDate dataReserva,
			int duracao) {
		for(Reserva res : reservas.values()) {
			if(res.equals(reserva)) {
				res.setNome(nome);
				res.setQtdPessoas(qtdpessoas);
				res.setNumeroContato(numeroCon);
				res.setDataReserva(dataReserva);
				res.setDuracao(duracao);
			}
		}
	}

	@Override
	public String Listar() {
		// TODO Auto-generated method stub
		String str = "";
		for(Reserva res : reservas.values()) {
			str += res.toString();
		}
		return str;
	}

	@Override
	public void remove(Reserva reserva) {
		// TODO Auto-generated method stub
		ControleMesa cMesa = new ControleMesa();
		for(Mesa mesa : cMesa.Mesas.values()) {
			if(mesa.getReserva().equals(reserva)) {
				mesa.setReserva(null);
				mesa.setDisponivel(true);
			}
		}
		reservas.remove(reserva.getNome(), reserva);
	}

}
