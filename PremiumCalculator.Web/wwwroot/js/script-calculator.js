var calculator = ((calculator, undefined) => {

    //Function that validates fields before Premium value search
    _validateForm = () => {
        let birthdate = document.getElementById('BirthDate');
        let state = document.getElementById('State');
        let age = document.getElementById('Age');
        let count = 0;
        let classNameErrors = 'form-errors';
        $("." + classNameErrors).remove();

        //Validate BirthDate value and validate that Age registered be the same as Age calculated with BirthDate value
        if (birthdate.value == '') {
            birthdate.classList.add('error-form');
            birthdate.insertAdjacentHTML('afterEnd', `<label class="label-error ${classNameErrors}">Date of birth is a required field.</label>`)
            count++;
        } else {
            let birthdateToValid = new Date(birthdate.value);
            let today = new Date();
            let ageToValid = today.getFullYear() - birthdateToValid.getFullYear();
            let m = today.getMonth() - birthdateToValid.getMonth();

            if (m < 0 || (m === 0 && today.getDate() < birthdateToValid.getDate())) {
                ageToValid--;
            }

            if (ageToValid != age.value) {
                birthdate.classList.add('error-form');
                birthdate.insertAdjacentHTML('afterEnd', `<label class="label-error ${classNameErrors}">Age calculated with Date of Birth is not the same as age registered.</label>`)
                age.classList.add('error-form');
                age.insertAdjacentHTML('afterEnd', `<label class="label-error ${classNameErrors}">Age registered is not the same as age calculated with Date of Birth.</label>`)
                count++;
            }
            else {
                birthdate.classList.remove('error-form');
                age.classList.remove('error-form');
            }                
        }            

        //Validate that state has a valid selected value
        if (state.innerHTML == '' || state.value == '') {
            state.classList.add('label-error');
            state.insertAdjacentHTML('afterEnd', `<label class="label-error ${classNameErrors}">State is a required field.</label>`)
            count++;
        } else
            state.classList.remove('label-error');

        //Validate that age has a valid registered value
        if (age.value == '') {
            age.classList.add('label-error');
            age.insertAdjacentHTML('afterEnd', `<label class="label-error ${classNameErrors}">Age is a required field.</label>`)
            count++;
        } else
            age.classList.remove('label-error');

        return count > 0 ? false : true;
    };

    calculator.clickGetValue = () => {
        //Capture event click "Get Value" button to run Premium Value search
        $("#btnGetValue").click((e) => {
            e.preventDefault();
            calculator.calculatePremiumValue();
        });
    };

    //Function that cleans calculation fields if an error happens
    _cleanCalculatedFields = () => {
        document.getElementById('MonthlyValue').value = '';
        document.getElementById('AnnualValue').value = '';
        document.getElementById("PremiumValue").value = '';
        document.getElementById("Frequence").value = '';
        document.getElementById("Frequence").disabled = true;
    }

    //Function that runs premium value search
    calculator.calculatePremiumValue = () => {
        //First: Validate value fields
        if (!_validateForm()) {
            _cleanCalculatedFields();
            return true;
        }

        //Second: Get value fields
        let eState = document.getElementById("State");
        let paramState = eState.options[eState.selectedIndex].value;
        let paramBirthDate = document.getElementById('BirthDate').value;
        let paramAge = document.getElementById('Age').value;

        //Thrird: Insert params into an object to access the action
        let parameters = {
            BirthDate: paramBirthDate,
            State: paramState,
            Age: paramAge
        };

        //Fourth: Invoque action CalculatePremiumValue that runs search
        let url = '/Calculator/CalculatePremiumValue';
        $.ajax({
            url: url,
            data: parameters,
            type: 'POST',
            success: (data) => {
                //Validate data and data result to set or not premium value
                if (!$.isEmptyObject(data) && !$.isEmptyObject(data.result)) {
                    document.getElementById("Frequence").disabled = false;

                    document.getElementById("PremiumValue").value = data.result.premium;
                }
                else {
                    //If data result is not correct disable Frequence and clean PremiumValue, AnnualValue and MonthlyValue
                    document.getElementById("Frequence").disabled = true;

                    if (!$.isEmptyObject(data.exceptionMessage)) {
                        alert(data.exceptionMessage);
                    } else if (data.result === null) {
                        _cleanCalculatedFields();
                        alert('There is no value for this case!');
                    }
                    
                }
            }
        });
    };

    //Function that capture BirthDate change event
    calculator.onDateChange = () => {

        $("#BirthDate").change((e) => {
            //Calculate age value
            let birthDate = new Date(e.target.value);
            let today = new Date();
            let age = today.getFullYear() - birthDate.getFullYear();
            let m = today.getMonth() - birthDate.getMonth();

            if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                age--;
            }

            if (age < 0) {
                alert("Date of Birth value cannot be a future date");
                document.getElementById('BirthDate').value = today;
                age = '';
            }

            //Set value calculated on Age field 
            document.getElementById('Age').value = age;
        });
    };

    //Function that capture Frequence change event
    calculator.onFrequenceChange = () => {
        $("#Frequence").change((e) => {
            let frequence = e.target.value.split('|');
            let premium = document.getElementById('PremiumValue').value;
            let errorValidate = false;

            if (frequence.length > 1) {
                //Validate divisor value diffent to NaN and greater than zero 
                if (isNaN(frequence[1]))
                    errorValidate = true;
                else if (frequence[1] <= 0)
                    errorValidate = true;

                //If obtain an error show alert and set frequence to default
                if (errorValidate) {
                    alert('There is a problem with the frequence selected. Divisor value must be more than zero!');
                    document.getElementById('Frequence').value = '';
                } else {
                    //Set MonthlyValue and AnnualValue with premium and frequence values
                    document.getElementById('MonthlyValue').value = (premium / frequence[1]).toFixed(2);
                    document.getElementById('AnnualValue').value = (premium * (12 / frequence[1])).toFixed(2);
                }                
            }
        });
    };

    //Function that load combo state
    calculator.loadComboState = () => {

        $.ajax({
            type: 'get',
            url: '/Calculator/GetStates',
            async: true,
            dataType: "json",
            contentType: 'application/json',
            processData: true
        }).done((data) => {
            //Validate data and data result to set or not list obtained to state field
            if (!$.isEmptyObject(data) && !$.isEmptyObject(data.result)) {
                let select = document.getElementById('State');
                let options = '<option value="">--Select--</option>';
                for (let item of data.result) {
                    options += `<option value="${item.code}">${item.name}</option>`;
                }
                select.innerHTML = options;
            } else {
                alert('Connection with web service is closed!');
            }
        });
    };

    //Function that load combo frequence
    calculator.loadComboFrequence = () => {

        $.ajax({
            type: 'get',
            url: '/Calculator/GetFrequencies',
            async: true,
            dataType: "json",
            contentType: 'application/json',
            processData: true
        }).done((data) => {
            //Validate data and data result to set or not list obtained to frequence field
            if (!$.isEmptyObject(data) && !$.isEmptyObject(data.result)) {
                let select = document.getElementById('Frequence');
                let options = '<option value="">--Select--</option>';
                for (let item of data.result) {
                    options += `<option value="${item.code}|${item.months}">${item.name}</option>`;
                }
                select.innerHTML = options;
            } else {
                alert('Connection with web service is closed!');
            }
        });
    };

    return calculator;
})(calculator || {});