using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macc
{
    class Events
    {
        private DateTime activity_time;
        private string activity_module;
        private string  activity_invo;
        private string activity_action;
        public Events() { }
        public Events(DateTime time, string module, string  Ref, string action = " ")
        {
            activity_time = time;
            activity_module = module;
            activity_invo = Ref;
            activity_action = action;
        }
        public DateTime Time
        {
            get { return this.activity_time; }
        }
        public string Module
        {
            get { return activity_module; }
        }
        public string Ref
        {
            get { return activity_invo; }
        }
        public string Action
        {
            get { return activity_action; }
        }
    }
    
    class EventManager : IObservable<Events>
    {
        private List<IObserver<Events>> observers;
        private List<Events> Elist;
        public EventManager()
        {
            observers = new List<IObserver<Events>>();

            Elist = new List<Events>();
        }
        public void NewEvent(Events b)
        {
            Elist.Add(b);
        }
        public IDisposable Subscribe(IObserver<Events> observer)
        {
            // Check whether observer is already registered. If not, add it
            //if (!observers.Contains(observer))
            //{
                observers.Add(observer);
                
                    observer.OnNext(Elist.ElementAt<Events>(Elist.Count-1 ));
                
            //}
            return new Unsubscriber<Events>(observers, observer);
        }
    }

    class History : IObserver<Events>
    {
        private IDisposable newevent;
        private string name;
        public History(string mname)
        {
            this.name = mname;
            
        }
        public virtual void Subscribe(EventManager provider)
        {
            newevent = provider.Subscribe(this);

        }

        public virtual void Unsubscribe()
        {
            newevent.Dispose();
        }

        public virtual void OnCompleted()
        {
            //Console.WriteLine("On complete  " + this);
        }
        public virtual void OnNext(Events info)
        {
            Globals.historyList.Add(info);
          
             
        }

        // No implementation needed: Method is not called by the BaggageHandler class.
        public virtual void OnError(Exception e)
        {
            // No implementation.
        }
    }

    internal class Unsubscriber<Event> : IDisposable
    {
        private List<IObserver<Event>> _observers;
        private IObserver<Event> _observer;

        internal Unsubscriber(List<IObserver<Event>> observers, IObserver<Event> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }



}
