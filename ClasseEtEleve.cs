using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace HNI_TPmoyennes
{

    class Eleve
    {   // propriétés
        public string nom { get; }
        public string prenom { get; }
        public List<Note> notes { get; set; } = new List<Note>();
       

        // constructeur
        public Eleve (string leNom, string lePrenom)
        {
            nom = leNom;
            prenom = lePrenom; 
        }


        // méthodes
        public void ajouterNote(Note nvNote)
        {
            notes.Add(nvNote);
        }

        public float moyenneMatiere (int matiere)
        {   
            float total = 0;
            int j = 0;

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].matiere == matiere)
                {
                    total += notes[i].note;
                    j++;
                }
            }
            
            return (float) (Math.Truncate((total / j)*100) / 100);
        }

        public float moyenneGeneral () 
        {
            float total = 0; 
            List<float> matieresDiff = new List<float>();

            for (int i = 0; i < notes.Count; i++)
            {
                if (!matieresDiff.Contains(notes[i].matiere))
                {
                    matieresDiff.Add(notes[i].matiere); // création liste sans répétition de matière
                    total += moyenneMatiere(notes[i].matiere);
                }
            }
            
            return (float) (Math.Truncate((total / matieresDiff.Count) * 100) / 100);
        }
    }

    class Classe
    {   // propriétés
        public string nomClasse { get; }
        public List<string> matieres { get; set; } = new List<string> ();
        public List<Eleve> eleves { get; set; } = new List<Eleve>();


        // constructeur
        public Classe (string leNomClasse)
        {
            nomClasse = leNomClasse;
        }


        // méthodes
        public void ajouterEleve (string nom, string prenom )
        { 
            Eleve eleve = new Eleve(nom, prenom);
            eleves.Add (eleve);
        }

        public void ajouterMatiere (string matiere)
        { 
            matieres.Add (matiere);
        }

        public float moyenneMatiere (int matiere)
        {
            float total = 0;

            for (int i = 0; i < eleves.Count; i++)
            {
                total += eleves[i].moyenneMatiere(matiere);
            }
            
            return (float) (Math.Truncate((total / eleves.Count) * 100) / 100) ; 
        }

        public string moyenneGeneral ()
        {
            float total = 0;

            for ( int i = 0; i < matieres.Count; i++)
            {
                total += moyenneMatiere(i);
            }
            return (total / matieres.Count).ToString("0.##");
        }
    }
}