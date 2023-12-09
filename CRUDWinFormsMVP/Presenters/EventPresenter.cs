using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Views;

namespace CRUDWinFormsMVP.Presenters
{
    public class EventPresenter
    {
        //Fields
        private IEventView view;
        private IEventRepository repository;
        private BindingSource eventsBindingSource;
        private IEnumerable<EventModel> eventList;

        //Constructor
        public EventPresenter(IEventView view, IEventRepository repository)
        {
            this.eventsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchEvent;
            this.view.AddNewEvent += AddNewEvent;
            this.view.EditEvent += LoadSelectedEventToEdit;
            this.view.DeleteEvent += DeleteSelectedEvent;
            this.view.SaveEvent += SaveEvent;
            this.view.CancelEvent += CancelAction;
            //Set events bindind source
            this.view.SetEventListBindingSource(eventsBindingSource);
            //Load events list view
            LoadAllEventList();
            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllEventList()
        {
            eventList = repository.GetAll();
            eventsBindingSource.DataSource = eventList;//Set data source.
        }
        private void SearchEvent(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                eventList = repository.GetByValue(this.view.SearchValue);
            else eventList = repository.GetAll();
            eventsBindingSource.DataSource = eventList;
        }
        private void AddNewEvent(object sender, EventArgs e)
        {
            view.IsEdit = false;          
        }
        private void LoadSelectedEventToEdit(object sender, EventArgs e)
        {
            var pet = (EventModel) eventsBindingSource.Current;
            view.EventId = pet.Id.ToString();
            view.EventName = pet.Name;
            view.EventType = pet.Type;
            view.EventDescription = pet.Description;
            view.IsEdit = true;
        }
        private void SaveEvent(object sender, EventArgs e)
        {
            var model = new EventModel();
            model.Id = Convert.ToInt32(view.EventId);
            model.Name = view.EventName;
            model.Type = view.EventType;
            model.Description = view.EventDescription;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if(view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Event edited successfuly";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Event added sucessfully";
                }
                view.IsSuccessful = true;
                LoadAllEventList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.EventId = "0";
            view.EventName = "";
            view.EventType = "";
            view.EventDescription = "";            
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
        private void DeleteSelectedEvent(object sender, EventArgs e)
        {
            try
            {
                var pet = (EventModel)eventsBindingSource.Current;
                repository.Delete(pet.Id);
                view.IsSuccessful = true;
                view.Message = "Event deleted successfully";
                LoadAllEventList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete Event";
            }
        }

    }
}
