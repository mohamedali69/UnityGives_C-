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
    public class DonorPresenter
    {
        //Fields
        private IDonorView view;
        private IDonorRepository repository;
        private BindingSource donorsBindingSource;
        private IEnumerable<DonorModel> donorList;

        //Constructor
        public DonorPresenter(IDonorView view, IDonorRepository repository)
        {
            this.donorsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe donor handler methods to view donors
            this.view.SearchDonor += SearchDonor;
            this.view.AddNewDonor += AddNewDonor;
            this.view.EditDonor += LoadSelectedDonorToEdit;
            this.view.DeleteDonor += DeleteSelectedDonor;
            this.view.SaveDonor += SaveDonor;
            this.view.CancelDonor += CancelAction;
            //Set donors bindind source
            this.view.SetDonorListBindingSource(donorsBindingSource);
            //Load donors list view
            LoadAllDonorList();
            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllDonorList()
        {
            donorList = repository.GetAll();
            donorsBindingSource.DataSource = donorList;//Set data source.
        }
        private void SearchDonor(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                donorList = repository.GetByValue(this.view.SearchValue);
            else donorList = repository.GetAll();
            donorsBindingSource.DataSource = donorList;
        }
        private void AddNewDonor(object sender, EventArgs e)
        {
            view.IsEdit = false;          
        }
        private void LoadSelectedDonorToEdit(object sender, EventArgs e)
        {
            var selectedDonor = (DonorModel)donorsBindingSource.Current;
            view.DonorId = selectedDonor.Id.ToString();
            view.DonorName = selectedDonor.Name;
            view.DonorEmail = selectedDonor.Email;
            view.DonorPhoneNumber = selectedDonor.PhoneNumber;
            view.IsEdit = true;
        }

        private void SaveDonor(object sender, EventArgs e)
        {
            var model = new DonorModel();
            model.Id = Convert.ToInt32(view.DonorId);
            model.Name = view.DonorName;
            model.Email = view.DonorEmail;
            model.PhoneNumber = view.DonorPhoneNumber;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Donor edited successfully";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Donor added successfully";
                }
                view.IsSuccessful = true;
                LoadAllDonorList();
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
            view.DonorId = "0";
            view.DonorName = "";
            view.DonorEmail = "";
            view.DonorPhoneNumber = "";            
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
        private void DeleteSelectedDonor(object sender, EventArgs e)
        {
            try
            {
                var selectedDonor = (EventModel)donorsBindingSource.Current;
                repository.Delete(selectedDonor.Id);
                view.IsSuccessful = true;
                view.Message = "Event deleted successfully";
                LoadAllDonorList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error occurred, could not delete the Donor";
            }
        }

    }
}
