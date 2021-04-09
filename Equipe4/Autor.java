import java.util.ArrayList;
import java.util.Date;

public class Autor {
	public String nome;
	public String sobrenome;
	public String paisOrigem;
	public Date dataNascimento;
	public ArrayList<Livro> livros = new ArrayList<Livro>();
	
	public String getNome() {
		return nome;
	}
	
	public void setNome(String nome) throws Exception {
		if (nome.isEmpty() || nome.equalsIgnoreCase("")) {
			throw new Exception("Campo nome vazio");
		}
		this.nome = nome;
	}
	
	public String getSobrenome() {
		return sobrenome;
	}
	
	public void setSobrenome(String sobrenome) throws Exception {
		if (sobrenome.isEmpty() || sobrenome.equalsIgnoreCase("")) {
			throw new Exception("Campo sobrenome vazio");
		}
		this.sobrenome = sobrenome;
	}
	
	public String getPaisOrigem() {
		return paisOrigem;
	}
	
	public void setPaisOrigem(String paisOrigem) throws Exception {
		if (paisOrigem.isEmpty() || paisOrigem.equalsIgnoreCase("")) {
			throw new Exception("Campo país origem vazio");
		}
		this.paisOrigem = paisOrigem;
	}
	
	public Date getDataNascimento() {
		return dataNascimento;
	}
	
	public void setDataNascimento(Date dataNascimento) throws Exception {
		if (dataNascimento == null) {
			throw new Exception("Campo data de nascimento vazio");
		}
		if (dataNascimento.after(new Date())) {
			throw new Exception("Data de nascimento não pode ser superior ao dia de hoje");
		}
		this.dataNascimento = dataNascimento;
	}
	
	public ArrayList<Livro> getLivros() {
		return livros;
	}
	
	public void setLivros(ArrayList<Livro> livros) {
		this.livros = livros;
	}
}