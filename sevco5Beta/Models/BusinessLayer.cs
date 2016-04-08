using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sevco5Beta.Models;
using sevco5Beta.DataAccesLayer;
using System.Security.Cryptography;
using System.Text;

namespace sevco5Beta.Models
{
    public class BusinessLayer
    {
        public List<dominios> getDominios()
        {
            SevcoDB db = new SevcoDB();
            return db.dominios.ToList();
        }


        public List<procesos> getProcesos(int idproc)
        {
            using (SevcoDB db = new SevcoDB())
            {
                var v = db.procesos.Where(d => d.Id_Dominio == idproc).ToList();
                return v;
            }

        }


        public List<preguntas> getPreguntas(int idproc)
        {
            using (SevcoDB db = new SevcoDB())
            {
                var mets = (from lpm in db.lnk_proceso_metas
                            join p in db.procesos on lpm.Id_proceso equals p.Id_proceso
                            join m in db.metas on lpm.Id_meta equals m.Id_meta
                            where p.Id_proceso == idproc
                            select m.Id_meta).ToList();

                // var query = db.preguntas.Where(m=>mets.Contains(m.Id_meta)).ToList();
                return db.preguntas.Where(m => mets.Contains(m.Id_meta)).ToList();


            }


        }



        public List<Evaluaciones> getEvaluaciones_xproces(int Id_proceso)
        {
            using(SevcoDB db = new SevcoDB())
            {
                 var evas =db.Evaluaciones.Where(e => e.Id_proceso == Id_proceso).ToList();
                 return evas;
            }
        }


        



        public int CreateEvaluacion(Evaluaciones eva)
        {
            using (SevcoDB db = new SevcoDB())
            {
                db.Evaluaciones.Add(eva);
                db.SaveChanges();

                return db.Evaluaciones.Max(item => item.Id_evaluacion);
            }

        }

        public int CrearNuevo_Usr(usuarios datos)
        {
            string oldPass = datos.clave;
            datos.clave=getMD5(oldPass);

            using (SevcoDB db = new SevcoDB())
            {
                db.usuarios.Add(datos);
                db.SaveChanges();
                return db.SaveChanges();
            }
        }



        public proceso_respuestas SaveRespuestasPreguntas(proceso_respuestas pr)
        {
            using (SevcoDB db = new SevcoDB())
            {
                db.proceso_respuestas.Add(pr);
                db.SaveChanges();
                return pr;
            }
        }

        public UserStatus ValidarUsuario(usuarios user)
        {
            string md5clave = getMD5(user.clave);
            using (SevcoDB db = new SevcoDB())
            {
                var usr = db.usuarios.Where(u => u.usuario == user.usuario && u.clave == md5clave).FirstOrDefault();
                usuarios usuarioDatos=usr as usuarios;
                if (usr==null)//uu == null || uu.usuario!= user.usuario)
                {
                    return UserStatus.NonAuthenticatedUser;
                }
                else if(usuarioDatos.isAdmin)
                {
                    return UserStatus.AuthenticatedAdmin;
                }
                else
                {
                    return UserStatus.AuthentucatedUser; 
                }

            }

            
        }
        public bool IsValidUser(usuarios user)
        {
            string md5clave = getMD5(user.clave);
            using (SevcoDB db = new SevcoDB())
            {
                var usr = db.usuarios.Where(u => u.usuario == user.usuario && u.clave == md5clave).FirstOrDefault();
                if (usr == null)//uu == null || uu.usuario!= user.usuario)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

        }

        private string getMD5(string clave)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(clave);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }

        


        public List<grupos> getGrupos()
        { 
            using(SevcoDB db = new SevcoDB())
            {
                return db.grupos.ToList();
            }
        }



        ///////////////////////////////////////////////////  RESULTADOS ////////////////////////////////////////////////////////////

        public List<proceso_respuestas> getRespuesta_preguntas(int IdEvaluacion)
        {
            using (SevcoDB db = new SevcoDB())
            {
                var v = db.proceso_respuestas.Where(p => p.Id_evaluacion == IdEvaluacion).ToList();
                return v;
            }


        }



        public int GuardarResul_proceso(proceso_resultados pro)
        {
            using (SevcoDB db = new SevcoDB())
            {
                db.proceso_resultados.Add(pro);
               // db.SaveChanges();
                return db.SaveChanges();
            }
        }


        public List<proceso_resultados> GetResultado_procesos(int mes, int Iproceso)
        {
            using (SevcoDB db = new SevcoDB())
            {
                //var Eva = db.Evaluaciones.Where(e => e.Id_proceso== Iproceso && e.fechaEvaluacion.Month== mes).ToList();
                var ev = (from e in db.Evaluaciones
                            where e.Id_proceso== Iproceso && e.fechaEvaluacion.Month== mes
                              select e.Id_evaluacion).ToList();
                

                return db.proceso_resultados.Where(p => ev.Contains(p.Id_evaluacion)).ToList();
            }
            
        }


        
        

        



    }

}