import java.util.Date;

public class Livro {
	public Date dataPublicacao;
	public String titulo;
	public Autor autor;
	public String editora;
	public int paginas;
	public String generoLiterario;
	public boolean isDoado;
	
	public Date getDataPublicacao() {
		return dataPublicacao;
	}
	
	public void setDataPublicacao(Date dataPublicacao) throws Exception {
		if (dataPublicacao == null) {
			throw new Exception("Campo data de publicação vazio");
		}
		if (dataPublicacao.after(new Date())) {
			throw new Exception("Data de publicação não pode ser superior ao dia de hoje");
		}
		this.dataPublicacao = dataPublicacao;
	}
	
	public String getTitulo() {
		return titulo;
	}
	
	public void setTitulo(String titulo) throws Exception {
		if (isEmpty(titulo)) {
			throw new Exception("Campo título vazio");
		}
		this.titulo = titulo;
	}
	
	public Autor getAutor() {
		return autor;
	}
	
	public void setAutor(Autor autor) throws Exception {
		if (autor.equals(null)) {
			throw new Exception("Autor da obra não encontrado/cadastrado");
		}
		this.autor = autor;
	}
	
	public String getEditora() {
		return editora;
	}
	
	public void setEditora(String editora) throws Exception {
		if (isEmpty(editora)) {
			throw new Exception("Campo editora vazio");
		}
		this.editora = editora;
	}
	
	public int getPaginas() {
		return paginas;
	}
	
	public void setPaginas(int paginas) throws Exception {
		if (paginas <= 0) {
			throw new Exception("Campo páginas inválido");
		}
		this.paginas = paginas;
	}
	
	public boolean isDoado() {
		return isDoado;
	}
	
	public void setDoado(boolean isDoado) {
		this.isDoado = isDoado;
	}
	
	public String getGeneroLiterario() {
		return generoLiterario;
	}

	public void setGeneroLiterario(String generoLiterario) throws Exception {
		if (isEmpty(generoLiterario)) {
			throw new Exception("Campo gênero literário vazio");
		}
		this.generoLiterario = generoLiterario;
	}
        
        public boolean isEmpty (String value) {
            	return value == null || value.equals("") || value.isEmpty();
        }
}
