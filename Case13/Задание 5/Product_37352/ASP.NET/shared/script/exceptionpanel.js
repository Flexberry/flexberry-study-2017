    function OnErrorChanged(ctrl, arr)
    {
        for(var i = 0; i < arr.length; i++)
        {
            if(i == ctrl.value)
            {
                document.getElementById(arr[i]).style.display = "block";
            }
            else
            {
                document.getElementById(arr[i]).style.display = "none";
            }
        }
    }
