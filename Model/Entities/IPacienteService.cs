using System.Collections.Generic;

namespace ILab.Model
{
	public interface IPacienteService
	{
		void Delete(Paciente prPaciente);
		List<Paciente> GetAll();
		List<Paciente> GetById(int prId);
		List<Paciente> GetByName(string prName);
		Paciente Save(Paciente prPaciente);
		Paciente Update(Paciente prPaciente);
	}
}