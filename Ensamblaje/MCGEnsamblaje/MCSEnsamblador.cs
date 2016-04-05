using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCGEnsamblaje
{
    public class MCSEnsamblador
    {
        /*
         * Utiliza MyType, MyModule, Main y escribe en linea Hello World -> Por Defecto
         */
        private static void MakeAssembly(AssemblyName myAssemblyName, string fileName)
        {
            // Get the assembly builder from the application domain associated with the current thread.
            AssemblyBuilder myAssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);
            // Create a dynamic module in the assembly.
            ModuleBuilder myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("MyModule", fileName);
            // Create a type in the module.
            TypeBuilder myTypeBuilder = myModuleBuilder.DefineType("MyType");

            // Create a method called 'Main'.
            MethodBuilder myMethodBuilder = myTypeBuilder.DefineMethod("Main", MethodAttributes.Public | MethodAttributes.HideBySig |
               MethodAttributes.Static, typeof(void), null);
            // Get the Intermediate Language generator for the method.
            ILGenerator myILGenerator = myMethodBuilder.GetILGenerator();
            // Use the utility method to generate the IL instructions that print a string to the console.
            myILGenerator.EmitWriteLine("Hello World!");
            // Generate the 'ret' IL instruction.
            myILGenerator.Emit(OpCodes.Ret);


            //Get a method pre-compiled on the outside
            Assembly ass = Assembly.LoadFrom("hola.dll");
            MethodInfo miembroNuevo = null;
            foreach (var type in ass.GetTypes())
            {
                //MethodInfo[] members = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                MethodInfo[] members2 = type.GetMethods(BindingFlags.Public | BindingFlags.Static);

                foreach (MethodInfo member in members2)
                {
                    miembroNuevo = member as MethodInfo;
                    //Console.WriteLine(type.Name + "." + member.Name);
                }
            }
            MethodBuilder secondMB = myTypeBuilder.DefineMethod("Hola", miembroNuevo.Attributes);
            ILGenerator secondGen = secondMB.GetILGenerator();

            Byte[] bytes = secondMB.GetMethodBody().GetILAsByteArray();



            myILGenerator.Emit(OpCodes.Ret);

            // End the creation of the type.
            myTypeBuilder.CreateType();
            // Set the method with name 'Main' as the entry point in the assembly.
            myAssemblyBuilder.SetEntryPoint(myMethodBuilder);
            myAssemblyBuilder.Save(fileName);     

        }
        /*
         * Constructor personalizado
         */
        private static void MakeAssembly(AssemblyName myAssemblyName, string fileName, Dictionary<string, Dictionary<string, Dictionary<string, List<string> > > > config)
        {
            Dictionary<string, Dictionary<string, List<string> > > modulos = config["modulos"];

            // Get the assembly builder from the application domain associated with the current thread.
            AssemblyBuilder myAssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);

            foreach (KeyValuePair<string, Dictionary<string, List<string> > > itModulo in modulos)
            {
                // Create a dynamic module in the assembly.
                ModuleBuilder myModuleBuilder = myAssemblyBuilder.DefineDynamicModule(/*"MyModule"*/itModulo.Key, fileName);

                //Tipos se refiere a Clases
                foreach (string itTipo in itModulo.Value["tipos"])
                {
                    // Crear clase en el modulo
                    TypeBuilder myTypeBuilder = myModuleBuilder.DefineType(/*"MyType"*/itTipo);

                    // Crear metodos de la clase
                    ///TODO: paramatrizar la creacion de metodos
                    foreach (string itMetodo in itModulo.Value["metodos"])
                    {
                        // Create a method called 'Main'.
                        MethodBuilder myMethodBuilder = myTypeBuilder.DefineMethod(/*"Main"*/itMetodo, MethodAttributes.Public | MethodAttributes.HideBySig |
                        MethodAttributes.Static, typeof(void), null);
                        // Get the Intermediate Language generator for the method.
                        ILGenerator myILGenerator = myMethodBuilder.GetILGenerator();
                        // Use the utility method to generate the IL instructions that print a string to the console.
                        myILGenerator.EmitWriteLine("Hello World!");
                        // Generate the 'ret' IL instruction.
                        myILGenerator.Emit(OpCodes.Ret);
                        // End the creation of the type.
                        myTypeBuilder.CreateType();
                    }
                }
            }
            // Set the method with name 'Main' as the entry point in the assembly.
            //myAssemblyBuilder.SetEntryPoint(myMethodBuilder);
            myAssemblyBuilder.Save(fileName);
         }

        public static void Ensamblar(Dictionary<string, string> parametros)
        {
            // Create a dynamic assembly with name 'MyAssembly' and build version '1.0.0.2001'.
            AssemblyName myAssemblyName = new AssemblyName();
            myAssemblyName.Name = /*"MyAssembly"*/parametros["nombrensamblado"];
            myAssemblyName.Version = new Version(/*"1.0.0.2001"*/parametros["versionsamblado"]);
            MakeAssembly(myAssemblyName, /*"MyAssembly"*/parametros["nombrensamblado"]+ ".exe");

            // Get all the assemblies currently loaded in the application domain.
            Assembly[] myAssemblies = Thread.GetDomain().GetAssemblies();

            // Get the dynamic assembly named 'MyAssembly'. 
            Assembly myAssembly = null;
            for (int i = 0; i < myAssemblies.Length; i++)
            {
                if (String.Compare(myAssemblies[i].GetName().Name, /*"MyAssembly"*/parametros["nombrensamblado"]) == 0)
                    myAssembly = myAssemblies[i];
            }
            if (myAssembly != null)
            {
                Console.WriteLine("\nDisplaying the assembly name\n");
                Console.WriteLine(myAssembly);
            }
        }

    }
}
